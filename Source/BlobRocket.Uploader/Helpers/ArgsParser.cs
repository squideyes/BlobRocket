using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BlobRocket.Uploader
{
    public class ArgsParser<O> where O : Options, new()
    {
        private class Spec
        {
            public PropertyInfo Property { get; set; }
            public Type Type { get; set; }
            public string HelpText { get; set; }
            public OptionKind Kind{ get; set; }
        }

        private Dictionary<string, Spec> specs = new Dictionary<string, Spec>();

        public ArgsParser()
        {
        }

        public O Parse(string[] args)
        {
            var options = new O();

            var properties = typeof(O).GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var property in typeof(O).
                GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                var attrib = property.GetCustomAttribute<OptionAttribute>();

                if (attrib == null)
                    continue;

                if (attrib.Key == null)
                    throw new ArgumentNullException(nameof(attrib.Key));

                if (attrib.Alias == null)
                    throw new ArgumentNullException(nameof(attrib.Alias));

                // validate type

                var key = attrib.Key.ToLower();
                var alias = attrib.Alias.ToLower();

                var spec = new Spec()
                {
                    Property = property,
                    Type = property.PropertyType,
                    HelpText = attrib.HelpText,
                    Kind = attrib.Kind
                };

                specs.Add(key, spec);
                specs.Add(alias, spec);
            }

            var chunks = GetChunks(args);

            foreach (var chunk in chunks)
            {
                var tv = new TokenValue(chunk.Substring(1));

                Spec spec;

                if (specs.TryGetValue(tv.Token, out spec))
                {
                    if (!tv.HasValue)
                    {
                        SetValue(spec.Property, options, true);
                    }
                    else if (spec.Type.IsEnum)
                    {
                        var value = Enum.Parse(spec.Type, tv.Value, true);

                        SetValue(spec.Property, options, value);
                    }
                    else
                    {
                        if (spec.Type.GetInterface(typeof(IConvertible).FullName) != null)
                        {
                            var value = Convert.ChangeType(tv.Value, spec.Type);

                            SetValue(spec.Property, options, value);
                        }
                        else
                        {
                            if (spec.Type == typeof(List<string>))
                            {
                                var value = (string)Convert.ChangeType(tv.Value, typeof(string));

                                var items = value.Split(new char[] { ' ', ',', ';' }).ToList();

                                SetValue(spec.Property, options, items);
                            }
                            else
                            {
                                //can't assign
                            }
                        }
                    }
                }
                else
                {
                    // add not found 
                }
            }

            return options;
        }

        private void SetValue(PropertyInfo info, object instance, object value)
        {
            var targetType = info.PropertyType.IsNullableType()
                 ? Nullable.GetUnderlyingType(info.PropertyType)
                 : info.PropertyType;

            var convertedValue = Convert.ChangeType(value, targetType);

            info.SetValue(instance, convertedValue, null);
        }

        private List<string> GetChunks(string[] args)
        {
            //handle malformed  args with no dash to start

            //use regex!!!!!!!!!!!!!!!!!
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
