using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;
using CppSharp.Parser;
using CppAbi = CppSharp.Parser.AST.CppAbi;

namespace cppsharptest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------DumpSdkIncludes");
            MSVCToolchain.DumpSdkIncludes(VisualStudioVersion.VS2017);
            Console.WriteLine("\n----------DumpSdks");
            MSVCToolchain.DumpSdks();

            Console.WriteLine("----------start");
            ConsoleDriver.Run(new SampleLibrary());



            Console.Read();

        }
    }

    internal class SampleLibrary : ILibrary
    {
        #region Implementation of ILibrary

        public void Preprocess(Driver driver, ASTContext ctx)
        {

        }

        public void Postprocess(Driver driver, ASTContext ctx)
        {

        }

        public void Setup(Driver driver)
        {
            var options = driver.Options;
          //  driver.ParserOptions.SystemIncludeDirs.Add();
            driver.ParserOptions.Abi = CppAbi.Microsoft;
            driver.ParserOptions.MicrosoftMode = true;
            driver.ParserOptions.SetupMSVC(VisualStudioVersion.VS2017);

            driver.ParserOptions.SystemIncludeDirs.Add(@"D:\Windows Kits\10\Include\10.0.17763.0\shared");
            driver.ParserOptions.SystemIncludeDirs.Add(@"D:\Windows Kits\10\Include\10.0.17763.0\ucrt");
            driver.ParserOptions.SystemIncludeDirs.Add(@"D:\Windows Kits\10\Include\10.0.17763.0\um");



            //  driver.ParserOptions.ForceClangToolchainLookup = true;
            options.GeneratorKind = GeneratorKind.CSharp;
            var module = options.AddModule("WeTest");
       
            module.IncludeDirs.Add(@"E:\vsproject\cppsharptest\Dll1");

            


            //D:\Windows Kits\10\Include\10.0.17763.0\um\Windows.h
            module.Headers.Add("we.h");

          


        }

        public void SetupPasses(Driver driver)
        {

        }

        #endregion
    }
}
