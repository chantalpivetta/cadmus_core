﻿using Cadmus.Core;
using Cadmus.Parts.General;
using Cadmus.Seed.Parts.General;
using Xunit;

namespace Cadmus.Seed.Parts.Test
{
    public sealed class TokenTextPartSeederTest
    {
        private static readonly PartSeederFactory _factory;
        private static readonly SeedOptions _seedOptions;
        private static readonly IItem _item;

        static TokenTextPartSeederTest()
        {
            _factory = TestHelper.GetFactory();
            _seedOptions = _factory.GetSeedOptions();
            _item = _factory.GetItemSeeder().GetItem(1, "facet");
        }

        [Fact]
        public void Seed_Options_Tag()
        {
            TokenTextPartSeeder seeder = new TokenTextPartSeeder();
            seeder.SetSeedOptions(_seedOptions);

            IPart part = seeder.GetPart(_item, null, _factory);

            Assert.NotNull(part);

            TokenTextPart tp = part as TokenTextPart;
            Assert.NotNull(tp);

            TestHelper.AssertPartMetadata(tp);
            Assert.NotEmpty(tp.Lines);

            for (int y = 1; y <= tp.Lines.Count; y++)
            {
                Assert.Equal(y, tp.Lines[y - 1].Y);
            }
        }
    }
}
