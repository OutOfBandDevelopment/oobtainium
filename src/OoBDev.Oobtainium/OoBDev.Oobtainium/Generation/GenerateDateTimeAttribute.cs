using System;
using System.Collections.Generic;
using System.Linq;

namespace OoBDev.Oobtainium.Generation
{
    public class GenerateDateTimeAttribute : GenerateLongAttribute
    {
        public override bool CanGenerateValue(IProcedualGenerationContext context) =>
            new[] {
                typeof(TimeSpan), typeof(TimeSpan?),
                typeof(DateTime), typeof(DateTime?),
                typeof(DateTimeOffset), typeof(DateTimeOffset?),
            }.Contains(context.TargetType);

        protected override object? OnGenerateValue(IProcedualGenerationContext context)
        {
            var result = (long?)base.OnGenerateValue(context);

            if (!result.HasValue) return null;

            if (context.TargetType == typeof(TimeSpan) || context.TargetType == typeof(TimeSpan?))
                return new TimeSpan(TimeSpan.MinValue.Ticks + (result.Value % (TimeSpan.MaxValue.Ticks - TimeSpan.MinValue.Ticks)));

            var dateTime = new DateTime(DateTime.MinValue.Ticks + (result.Value % (DateTime.MaxValue.Ticks - DateTime.MinValue.Ticks)));

            if (context.TargetType == typeof(DateTime) || context.TargetType == typeof(DateTime?)) return dateTime;
            else if (context.TargetType == typeof(DateTimeOffset) || context.TargetType == typeof(DateTimeOffset?))
            {
                var tzi = TimeZoneInfo.GetSystemTimeZones()[context.Random.Next() % TimeZoneInfo.GetSystemTimeZones().Count];
                var tz = tzi.GetUtcOffset(dateTime);
                return new DateTimeOffset(dateTime, tz);
            }

            throw new NotSupportedException($"type {context.TargetType} is not supported");
        }
    }
}
