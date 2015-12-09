using System;
using System.Reflection;
using System.Text;

namespace BlobRocket.Uploader
{
    public class AppInfo
    {
        private string product;
        private Version version;

        public AppInfo(Assembly assembly)
        {
            Contract.Requires(assembly != null, nameof(assembly));

            Copyright = GetCopyright(assembly);

            product = GetEntryProduct(assembly);
            version = assembly.GetName().Version;
        }

        public string Copyright { get; }

        public string GetTitle(string extraInfo = null)
        {
            var sb = new StringBuilder();

            sb.Append(product);

            if (!string.IsNullOrWhiteSpace(extraInfo))
            {
                sb.Append(" (");
                sb.Append(extraInfo);
                sb.Append(')');
            }

            sb.Append(" v");
            sb.Append(version.Major);
            sb.Append('.');
            sb.Append(version.Minor);

            if ((version.Build != 0) || (version.Revision != 0))
            {
                sb.Append('.');
                sb.Append(version.Build);
            }

            if (version.Revision == 0) 
                return sb.ToString();

            sb.Append('.');
            sb.Append(version.Revision);

            return sb.ToString();
        }

        private static string GetEntryProduct(Assembly assembly)
        {
            return assembly.GetAttribute<AssemblyProductAttribute>().Product;
        }

        private static string GetCopyright(Assembly assembly)
        {
            return assembly.GetAttribute<AssemblyCopyrightAttribute>().Copyright;
        }
    }
}
