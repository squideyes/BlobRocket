using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Linq;

namespace BlobRocket.Uploader.Generics
{
    public class ArgsParser<O> where O : OptionsBase, new()
    {
        private class Spec
        {
            public PropertyInfo Property { get; set; }
            public Type Type { get; set; }
            public string HelpText { get; set; }
            public OptionKind Kind { get; set; }
            public Func<string, bool> Validator { get; set; }
        }

        private Dictionary<string, Spec> specs = new Dictionary<string, Spec>();

        public void Setup<R>(Expression<Func<O, R>> property,
            char key, string alias, OptionKind kind, string helpText)
        {
            Setup(property, key, alias, kind, helpText, null);
        }

        public void Setup<R>(Expression<Func<O, R>> property, 
            char key, string alias, OptionKind kind, string helpText, 
            Func<string, bool> validator)
        {
            // validate args

            var p = GetProperty(property);

            var spec = new Spec()
            {
                Property = p,
                Type = p.PropertyType,
                Kind = kind,
                HelpText = helpText,
                Validator = validator
            };

            specs.Add(key.ToString(), spec);
            specs.Add(alias, spec);
        }

        public O Parse(string[] args)
        {
            var options = new O();

            foreach (var chunk in GetChunks(args))
            {
                var tv = new TokenValue(chunk.Substring(1));

                Spec spec;

                if (specs.TryGetValue(tv.Token, out spec))
                {
                    if (!tv.HasValue)
                    {
                        SetValue(options, spec, tv, options, true);
                    }
                    else if (spec.Type.IsEnum)
                    {
                        var value = Enum.Parse(spec.Type, tv.Value, true);

                        SetValue(options, spec, tv, options, value);
                    }
                    else if (typeof(IConvertible).IsAssignableFrom(spec.Type))
                    {
                        var value = Convert.ChangeType(tv.Value, spec.Type);

                        SetValue(options, spec, tv, options, value);
                    }
                    else if (spec.Type == typeof(List<string>))
                    {
                        var value = (string)Convert.ChangeType(tv.Value, typeof(string));

                        var items = value.Split(new char[] { ' ', ',', ';' }).ToList();

                        SetValue(options, spec, tv, options, items);
                    }
                    else
                    {
                        options.Errors.Add(new ParseError(tv,
                            "The {0} argument could not be parsed!", spec.Type));
                    }
                }
            }

            return options;
        }

        private PropertyInfo GetProperty<R>(Expression<Func<O, R>> expression)
        {
            if (expression.Body is MemberExpression)
                return (PropertyInfo)((MemberExpression)expression.Body).Member;
            else
                throw new ArgumentException();
        }

        private void SetValue(O options, Spec spec, TokenValue tv, object instance, object value)
        {
            try
            {
                var targetType = spec.Property.PropertyType.IsNullableType()
                     ? Nullable.GetUnderlyingType(spec.Property.PropertyType)
                     : spec.Property.PropertyType;

                var convertedValue = Convert.ChangeType(value, targetType);

                spec.Property.SetValue(instance, convertedValue, null);
            }
            catch (Exception error)
            {
                options.Errors.Add(new ParseError(tv, error.Message));
            }
        }

        private List<string> GetChunks(string[] args)
        {
            var cmd = (" " + string.Join(" ", args)).Replace(" /", " -").Trim();

            var chunks = new List<string>();

            while (cmd.Length > 0)
            {
                var index = cmd.IndexOf(" -");

                if (index == -1)
                {
                    chunks.Add(cmd);

                    cmd = "";
                }
                else
                {
                    chunks.Add(cmd.Substring(0, index));

                    cmd = cmd.Remove(0, index + 1);
                }
            }

            return chunks;
        }
    }
}
