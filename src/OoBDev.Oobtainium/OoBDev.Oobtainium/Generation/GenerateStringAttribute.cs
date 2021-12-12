using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OoBDev.Oobtainium.Generation
{
    public class GenerateStringAttribute : GenerateNullableAttribute
    {
        public override bool CanGenerateValue(IProcedualGenerationContext context) =>
            new[] {
                typeof(string),
            }.Contains(context.TargetType);

        protected override object? OnGenerateValue( IProcedualGenerationContext context)
        {
            // https://stackoverflow.com/questions/4286487/is-there-any-lorem-ipsum-generator-in-c
            var words = new[]{
                "lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
                "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
                "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"
            };

            int minWords = 1, maxWords = 5,
                 minSentences = 1, maxSentences = 5,
                 numParagraphs = 2;

            int numSentences = context.Random.Next(maxSentences - minSentences) + minSentences;
            int numWords = context.Random.Next(maxWords - minWords) + minWords;

            var result = new StringBuilder();

            for (int p = 0; p < numParagraphs; p++)
            {
                for (int s = 0; s < numSentences; s++)
                {
                    for (int w = 0; w < numWords; w++)
                    {
                        if (w > 0) { result.Append(" "); }
                        result.Append(words[context.Random.Next(words.Length)]);
                    }
                    result.Append(". ");
                }
                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
