using System.Runtime.InteropServices;
using System.Security;

namespace Bitshuffle.PInvoke
{
    public static class BitshuffleMethods
    {
        [SuppressUnmanagedCodeSecurity]
        [DllImport(Constants.NATIVE_DLL_NAME)]
        public static extern unsafe int bshuf_using_NEON();

        [SuppressUnmanagedCodeSecurity]
        [DllImport(Constants.NATIVE_DLL_NAME)]
        public static extern unsafe int bshuf_using_SSE2();

        [SuppressUnmanagedCodeSecurity]
        [DllImport(Constants.NATIVE_DLL_NAME)]
        public static extern unsafe int bshuf_using_AVX2();

        [SuppressUnmanagedCodeSecurity]
        [DllImport(Constants.NATIVE_DLL_NAME)]
        public static extern unsafe int bshuf_using_AVX512();

        [SuppressUnmanagedCodeSecurity]
        [DllImport(Constants.NATIVE_DLL_NAME)]
        public static extern unsafe nint bshuf_default_block_size(nint elem_size);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(Constants.NATIVE_DLL_NAME)]
        public static extern unsafe long bshuf_bitshuffle(void* @in, void* @out, nint size, nint elem_size, nint block_size);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(Constants.NATIVE_DLL_NAME)]
        public static extern unsafe long bshuf_bitunshuffle(void* @in, void* @out, nint size, nint elem_size, nint block_size);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(Constants.NATIVE_DLL_NAME)]
        public static extern unsafe nint bshuf_compress_lz4_bound(nint size, nint elem_size, nint block_size);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(Constants.NATIVE_DLL_NAME)]
        public static extern unsafe long bshuf_compress_lz4(void* @in, void* @out, nint size, nint elem_size, nint block_size);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(Constants.NATIVE_DLL_NAME)]
        public static extern unsafe long bshuf_decompress_lz4(void* @in, void* @out, nint size, nint elem_size, nint block_size);
    }
}