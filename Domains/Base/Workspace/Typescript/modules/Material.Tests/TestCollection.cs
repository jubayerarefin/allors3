﻿namespace Intranet.Tests
{
    using Xunit;

    [CollectionDefinition("Test collection")]
    public class TestCollection : ICollectionFixture<TestFixture>
    {
    }
}