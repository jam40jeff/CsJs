// Guids.cs
// MUST match guids.h

using System;

namespace MorseCode.CsJs.Tools.VSIXExtension.MarkupGeneratorPackage
{
    static class GuidList
    {
        public const string guidMarkupGeneratorPackagePkgString = "4d5a827f-1536-4635-be15-b85f3bca21bd";
        public const string guidMarkupGeneratorPackageCmdSetString = "66d13f67-b7a3-470c-9ae9-b60d65f61c85";

        public static readonly Guid guidMarkupGeneratorPackageCmdSet = new Guid(guidMarkupGeneratorPackageCmdSetString);
    };
}