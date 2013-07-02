// Guids.cs
// MUST match guids.h

using System;

namespace MorseCode.CsJs.Tools.VSIXExtension.ServiceReferenceGeneratorPackage
{
    static class GuidList
    {
        public const string guidServiceReferenceGeneratorPackagePkgString = "799eeb6d-ed08-4021-bc01-e83f9719472f";
        public const string guidServiceReferenceGeneratorPackageCmdSetString = "ecfea2cc-8330-40c0-8e34-2dd6687fdd38";

        public static readonly Guid guidServiceReferenceGeneratorPackageCmdSet = new Guid(guidServiceReferenceGeneratorPackageCmdSetString);
    };
}