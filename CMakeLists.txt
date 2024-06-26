cmake_minimum_required(VERSION 3.27.1)
project(bitshuffle)

# variables

# We stick with SSE since there are no runtime
# checks for available instruction sets in the
# bitshuffle code.
# 
# set(CMAKE_C_FLAGS "-mavx2") 

set(SRC "native/bitshuffle/src")
set(LZ4 "native/bitshuffle/lz4")

# header files
file(GLOB HEADER_FILES ${LZ4}/*.h)
list(FILTER HEADER_FILES EXCLUDE REGEX h5)

# source files
file(GLOB SOURCE_FILES ${SRC}/*.c ${LZ4}/*.c)
list(FILTER SOURCE_FILES EXCLUDE REGEX "h5|hdf5")

# library
add_library(${PROJECT_NAME} SHARED 
    ${CMAKE_CURRENT_SOURCE_DIR}/exports.def
    ${SOURCE_FILES} 
    ${HEADER_FILES}
)

target_include_directories(${PROJECT_NAME} PRIVATE ${LZ4})