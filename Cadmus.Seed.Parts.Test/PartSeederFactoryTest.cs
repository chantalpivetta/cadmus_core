using Cadmus.Seed.Parts.General;
using System.Collections.Generic;
using Xunit;

namespace Cadmus.Seed.Parts.Test
{
    public class PartSeederFactoryTest
    {
        static private readonly PartSeederFactory _factory =
            TestHelper.GetFactory();

        [Fact]
        public void GetItemSeeder_Ok()
        {
            ItemSeeder seeder = _factory.GetItemSeeder();

            Assert.NotNull(seeder);
        }

        [Fact]
        public void GetPartSeeders_Ok()
        {
            Dictionary<string, IPartSeeder> seeders = _factory.GetPartSeeders();

            Assert.NotNull(seeders);
            Assert.Equal(5, seeders.Count);

            string key = "net.fusisoft.categories";
            Assert.True(seeders.ContainsKey(key));
            Assert.NotNull(seeders[key] as CategoriesPartSeeder);

            key = "net.fusisoft.historical-date";
            Assert.True(seeders.ContainsKey(key));
            Assert.NotNull(seeders[key] as HistoricalDatePartSeeder);

            key = "net.fusisoft.keywords";
            Assert.True(seeders.ContainsKey(key));
            Assert.NotNull(seeders[key] as KeywordsPartSeeder);

            key = "net.fusisoft.note";
            Assert.True(seeders.ContainsKey(key));
            Assert.NotNull(seeders[key] as NotePartSeeder);

            key = "net.fusisoft.token-text";
            Assert.True(seeders.ContainsKey(key));
            Assert.NotNull(seeders[key] as TokenTextPartSeeder);
        }

        [Fact]
        public void GetFragmentSeeder_Comment_Ok()
        {
            IFragmentSeeder seeder = _factory.GetFragmentSeeder(
                "seed.fr.net.fusisoft.comment");
            Assert.NotNull(seeder);
        }
    }
}