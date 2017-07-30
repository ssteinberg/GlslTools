﻿using System;

namespace ShaderTools.VisualStudio.LanguageServices
{
    internal static class Guids
    {
        // Strings

        public const string ShaderToolsPackageIdString = "690E9FAE-6580-4566-8D7D-8B335CA27740";

        public const string GlslPackageIdString = "0E01DDB3-F537-4C49-9B50-BDA9DCCE2172";
        public const string GlslLanguageServiceIdString = "80329450-4B0D-4EC7-A4E4-A57C024888D5";

        public const string ShaderLabPackageIdString = "448635DC-AF8B-4767-BFDB-26ED6A865158";
        public const string ShaderLabLanguageServiceIdString = "E77D10A9-504A-45D6-B1AC-8492236D9564";

        // Guids

        public static readonly Guid ShaderToolsPackageId = new Guid(ShaderToolsPackageIdString);

        public static readonly Guid GlslPackageId = new Guid(GlslPackageIdString);
        public static readonly Guid GlslLanguageServiceId = new Guid(GlslLanguageServiceIdString);

        public static readonly Guid ShaderLabPackageId = new Guid(ShaderLabPackageIdString);
        public static readonly Guid ShaderLabLanguageServiceId = new Guid(ShaderLabLanguageServiceIdString);
    }
}
