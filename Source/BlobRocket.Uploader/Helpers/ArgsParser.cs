using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace BlobRocket.Uploader
{
    public class ArgsParser<O> where O : OptionsBase, new()
    {
        private class Spec
        {
            public PropertyInfo Property { get; set; }
            public Type Type { get; set; }
            public string HelpText { get; set; }
            public OptionKind Kind { get; set; }
        }

        private Dictionary<string, Spec> specs = new Dictionary<string, Spec>();

        public ArgsParser()
        {
            //var options = new O();

            //foreach (var property in typeof(O).
            //    GetProperties(BindingFlags.Instance | BindingFlags.Public))
            //{
            //    var attrib = property.GetCustomAttribute<OptionAttribute>();

            //    if (attrib == null)
            //        continue;

            //    if (attrib.Key == null)
            //        throw new ArgumentNullException(nameof(attrib.Key));

            //    if (attrib.Alias == null)
            //        throw new ArgumentNullException(nameof(attrib.Alias));

            //    var key = attrib.Key.ToLower();

            //    var alias = attrib.Alias.ToLower();

            //    var spec = new Spec()
            //    {
            //        Property = property,
            //        Type = property.PropertyType,
            //        HelpText = attrib.HelpText,
            //        Kind = attrib.Kind
            //    };

            //    specs.Add(key, spec);

            //    specs.Add(alias, spec);
            //}
        }

        public void Setup<R>(Expression<Func<O, R>> property, 
            char key, string alias, OptionKind kind, string helpText)
        {
            // validate

            var p = GetProperty(property);

            var spec = new Spec()
            {
                Property = p,
                Type = p.PropertyType,
                Kind = kind,
                HelpText = helpText
            };

            specs.Add(key.ToString(), spec);
            specs.Add(alias, spec);
        }

        private PropertyInfo GetProperty<R>(Expression<Func<O, R>> expression)
        {
            MemberExpression me = null;

            if (expression.Body is MemberExpression)
                me = (MemberExpression)expression.Body;
            else
                throw new ArgumentException();

            return (PropertyInfo)me.Member;
        }
    }
}
