using System;
using System.Linq;
using Nexus.Extensibility.Tests;
using Xunit;

namespace Bitshuffle.PInvoke.Tests;

public class PInvokeTests : IClassFixture<PInvokeFixture>
{
    [Fact]
    public void HasExpectedIntrinsics()
    {
        // Act
        var hasNEON = Bitshuffle.bshuf_using_NEON();
        var hasSSE2 = Bitshuffle.bshuf_using_SSE2();
        var hasAVX2 = Bitshuffle.bshuf_using_AVX2();
        var hasAVX512 = Bitshuffle.bshuf_using_AVX512();

        // Assert
        Assert.Equal(0, hasNEON);
        Assert.Equal(1, hasSSE2);
        Assert.Equal(0, hasAVX2);
        Assert.Equal(0, hasAVX512);
    }

    [Fact]
    public unsafe void CanRoundtrip()
    {
        // Arrange
        var random = new Random(Seed: 0);

        var original = Enumerable
            .Range(0, 100)
            .Select(_ => random.Next())
            .ToArray();

        var shuffled = new int[100];
        var unshuffled = new int[100];

        // Act
        fixed (int* originalPtr = original, shuffledPtr = shuffled, unshuffledPtr = unshuffled)
        {
            var bytesProcessed1 = Bitshuffle.bshuf_bitshuffle(
                @in: originalPtr,
                @out: shuffledPtr,
                size: original.Length,
                elem_size: sizeof(int),
                block_size: 0
            );

            Assert.Equal(400, bytesProcessed1);
            Assert.NotEqual(original[0], shuffled[0]);

            var bytesProcessed2 = Bitshuffle.bshuf_bitunshuffle(
                @in: shuffledPtr,
                @out: unshuffledPtr,
                size: original.Length,
                elem_size: sizeof(int),
                block_size: 0
            );

            Assert.Equal(400, bytesProcessed2);
        }

        // Assert
        Assert.True(original.SequenceEqual(unshuffled));
    }
}