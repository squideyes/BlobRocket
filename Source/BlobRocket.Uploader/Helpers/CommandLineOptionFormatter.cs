//using Fclp;
//using Fclp.Internals;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Reflection;
//using System.Text;

//namespace BlobRocket.Uploader
//{
//    internal class CommandLineOptionFormatter : ICommandLineOptionFormatter
//    {
//        public string Format(IEnumerable<ICommandLineOption> options)
//        {
//            var appInfo = new AppInfo(typeof(Program).Assembly);

//            var sb = new StringBuilder();

//            sb.AppendLine(appInfo.GetTitle());
//            sb.AppendLine(appInfo.Copyright.Replace("© ", "(c)"));
//            sb.AppendLine();

//            foreach (var option in options)
//            {
//                sb.Append((option.ShortName + ":" + option.LongName).PadRight(13));

//                string text = "";

//                if (option.HasDefault)
//                {
//                    //foreach (var property in ((Fclp.Internals.CommandLineOption<string>)option).GetType().GetProperties())
//                    //{
//                    //    System.Console.WriteLine(property);
//                    //}

//                    //var property = option.GetType().GetProperty("Default", BindingFlags.NonPublic);

//                    //var defaultValue = (string)property.GetValue(option, null);

//                    //text += string.Format("(Default: {0}) ", defaultValue);
//                }

//                text += option.Description;

//                var lines = text.ToWrappedLines(66);

//                for (int i = 0; i < lines.Count; i++)
//                {
//                    if (i > 0)
//                        sb.Append(new string(' ', 13));

//                    sb.AppendLine(lines[i]);
//                }

//                sb.AppendLine();
//            }

//            return sb.ToString();
//        }
//    }
//}
