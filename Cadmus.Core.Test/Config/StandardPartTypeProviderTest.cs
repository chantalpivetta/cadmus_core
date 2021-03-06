﻿using Cadmus.Core.Config;
using Cadmus.Parts.General;
using Cadmus.Parts.Layers;
using System;
using System.Reflection;
using Xunit;

namespace Cadmus.Core.Test.Config
{
    public sealed class StandardPartTypeProviderTest
    {
        private static IPartTypeProvider GetProvider()
        {
            TagAttributeToTypeMap map = new TagAttributeToTypeMap();
            map.Add(new Assembly[] { typeof(NotePart).Assembly });
            return new StandardPartTypeProvider(map);
        }

        [Fact]
        public void Get_NotExistingPart_Null()
        {
            Type t = GetProvider().Get("not-existing");

            Assert.Null(t);
        }

        [Fact]
        public void Get_NotePart_Ok()
        {
            Type t = GetProvider().Get("net.fusisoft.note");

            Assert.Equal(typeof(NotePart), t);
        }

        [Fact]
        public void Get_CommentLayerPart_Ok()
        {
            Type t = GetProvider().Get(
                "net.fusisoft.token-text-layer:fr.net.fusisoft.comment");

            Assert.Equal(typeof(TokenTextLayerPart<CommentLayerFragment>), t);
        }
    }
}
