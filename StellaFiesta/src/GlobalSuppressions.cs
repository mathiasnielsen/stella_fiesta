using System.Diagnostics.CodeAnalysis;

// NOTE: Taken from the BeoCloud project, commented out lines represent changes

[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA0001:XML documentation must be enabled")]

//Maintainability
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1404:Code analysis suppression must have justification")]

//[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed.")]

//Ordering
[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1200:Using directives must be placed correctly")]
[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1210:Using directives must be ordered alphabetically by namespace")]

//[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder")]
//[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1203:Constants must appear before fields")]
//[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1214:Readonly fields must appear before non-readonly fields")]
//[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess")]
//[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1204:StaticElementsMustAppearBeforeInstanceElements", Justification = "Reviewed.")]

//Readability
[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:Prefix local calls with this")]
[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1120:Comments must contain text")]
[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1649:File name must match first type name.")]

//[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:ParameterMustNotSpanMultipleLines")]
//[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1127:Generic type constraints must be on their own line")]
//[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1111:Closing parenthesis must be on line of last parameter")]
//[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1131:Use readable conditions")]

//Spacing
[assembly: SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1009:Closing parenthesis must be spaced correctly")]
[assembly: SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1005:Single line comments must begin with single space")]
[assembly: SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1000:Keywords must be spaced correctly")]
[assembly: SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1001:Commas must be spaced correctly")]

//[assembly: SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1028:Code must not contain trailing whitespace")]

//Naming
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1309:Field names must not begin with underscore")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:Field names must not contain underscore")]

//[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1306:Field names must begin with lower-case letter")]
//[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1311:StaticReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Reviewed.")]

//Layout
[assembly: SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1514:Element documentation header must be preceded by blank line")]
[assembly: SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1512:Single-line comments must not be followed by blank line")]

//Documentation
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:Enumeration items should be documented")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1623:Property summary documentation must match accessors")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1652:Enable XML documentation output")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1633:File must have header")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1611:Element parameters must be documented")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1615:Element return value must be documented")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1642:Constructor summary documentation must begin with standard text")]
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1618:Generic type parameters must be documented")]

//Security
[assembly: SuppressMessage("StyleCop.CSharp.SecurityRules", "CA2134:Generic type parameters must be documented")]

// Roslynator: Do not offer to remove trailing commas
[assembly: SuppressMessage("Redundancy", "RCS1035:Remove redundant comma in initializer.", Justification = "<Pending>")]