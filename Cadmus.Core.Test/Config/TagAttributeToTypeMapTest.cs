﻿using Cadmus.Core.Config;
using Cadmus.Parts.General;
using Cadmus.Parts.Layers;
using System;
using Xunit;

namespace Cadmus.Core.Test.Config
{
    public sealed class TagAttributeToTypeMapTest
    {
        private TagAttributeToTypeMap GetMap()
        {
            TagAttributeToTypeMap map = new TagAttributeToTypeMap();
            map.Add(new[] { typeof(NotePart).Assembly });
            return map;
        }

        [Fact]
        public void Get_NotExistingPart_Null()
        {
            TagAttributeToTypeMap map = GetMap();

            Type t = map.Get("not-existing");

            Assert.Null(t);
        }

        [Fact]
        public void Get_NotePart_Ok()
        {
            TagAttributeToTypeMap map = GetMap();

            Type t = map.Get("net.fusisoft.note");

            Assert.Equal(typeof(NotePart), t);
        }

        [Fact]
        public void Get_CommentLayerPart_Ok()
        {
            TagAttributeToTypeMap map = GetMap();

            Type t = map.Get(
                "net.fusisoft.token-text-layer:fr.net.fusisoft.comment");

            Assert.Equal(typeof(TokenTextLayerPart<CommentLayerFragment>), t);
        }
    }
}
