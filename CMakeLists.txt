message(
    STATUS "CMake version: "
           ${CMAKE_VERSION})

# ############################# Project generate options ###########################################################

set(ENABLE_COLORED_DIAGNOSTICS
    OFF
    CACHE BOOL
          "Enable colorful diagnostic messages from the compiler in console")

set(ENABLE_WARNINGS_AS_ERRORS
    OFF
    CACHE BOOL
          "Make compile warnings be treated as errors")

set(ENABLE_CCACHE
    OFF
    CACHE BOOL
          "Enable CCACHE")

set(ENABLE_COVERAGE
    OFF
    CACHE BOOL
          "Enable code coverage (Will force no optimizations)")

set(ENABLE_SANITIZERS
    OFF
    CACHE BOOL
          "Enable sanitizers (Only valid for Linux and Mac OS)")

set(ENABLE_STATIC_ANALYSIS
    ON
    CACHE BOOL
          "Enable CppCheck and clang-tidy")

set(ENABLE_INCLUDE_WHAT_YOU_USE
    ON
    CACHE BOOL
          "Enable iwyu")

set(USE_OSG
    ON
    CACHE BOOL
          "If projects that depend on osg should be compiled.")

set(USE_OSI
    ON
    CACHE BOOL
          "If code that depend on osi should be compiled.")

set(USE_SUMO
    ON
    CACHE BOOL
          "If code that depend on sumo should be compiled.")

set(USE_GTEST
    ON
    CACHE BOOL
          "If unit test suites based on googletest should be compiled.")

set(DYN_PROTOBUF
    OFF
    CACHE BOOL
          "Set for dynamic linking of protobuf library (.so/.dll)")

set(ESMINI_BUILD_VERSION
    "N/A - client build"
    CACHE STRING
          "Esmini CI Build Version")

# ############################### Setting project rules ############################################################

if(WIN32)
    cmake_minimum_required(
        VERSION 3.7.1 # for cmake generator VisualStudio 2017 support
        # VERSION 3.14   # for cmake generator VisualStudio 2019 support VERSION 3.19   # for cmake presets support
        FATAL_ERROR)
else()
    cmake_minimum_required(
        VERSION 2.8.12
        FATAL_ERROR)
endif()

project(
    esmini
    DESCRIPTION "esmini"
    LANGUAGES C
              CXX)

set_property(
    GLOBAL
    PROPERTY USE_FOLDERS
             ON)

include(support/cmake/rule/project_options.cmake)

if(${CMAKE_SYSTEM_NAME}
   MATCHES
   "Linux")
    set(LINUX
        true)
else()
    set(LINUX
        false)
endif()

if(NOT
   (LINUX
    OR APPLE
    OR MINGW
    OR MSVC))
    message(FATAL_ERROR "Unrecognized platform therefore there isn't an installation directory. Stopping the cmake process.")
endif()

# ############################### Loading common packages ############################################################

include(${CMAKE_CURRENT_SOURCE_DIR}/support/cmake/common/color.cmake)
include(${CMAKE_CURRENT_SOURCE_DIR}/support/cmake/common/locations.cmake)
include(${CMAKE_CURRENT_SOURCE_DIR}/support/cmake/common/definitions.cmake)
include(${CMAKE_CURRENT_SOURCE_DIR}/support/cmake/common/flags.cmake)

set_project_internal_paths()
set_project_external_paths()
set_project_os_specific_paths()
set_project_includes()
set_project_library_paths()
set_definitions()
set_special_build_flags()

# ############################### Loading utils packages ##############################################################

include(${CMAKE_CURRENT_SOURCE_DIR}/support/cmake/utils/get_subdirectories.cmake)
include(${CMAKE_CURRENT_SOURCE_DIR}/support/cmake/utils/set_folder.cmake)

# ############################### Loading cloud packages ##############################################################

set(FILE_STORAGE
    "esmini") # "dropbox", "google", "esmini"  (limited GB/Day)
set(MODEL_STORAGE
    "esmini") # "dropbox", "google", "esmini"  (limited GB/Day)

include(${CMAKE_CURRENT_SOURCE_DIR}/support/cmake/cloud/dropbox.cmake)
include(${CMAKE_CURRENT_SOURCE_DIR}/support/cmake/cloud/esmini.cmake)
include(${CMAKE_CURRENT_SOURCE_DIR}/support/cmake/cloud/googledrive.cmake)

if(${FILE_STORAGE}
   STREQUAL
   "dropbox")
    set_dropbox_cloud_links()
elseif(
    ${FILE_STORAGE}
    STREQUAL
    "google")
    set_googledrive_cloud_links()
elseif(
    ${FILE_STORAGE}
    STREQUAL
    "esmini")
    set_esmini_cloud_links()
else()
    message(
        "Unknown storage type: "
        ${FILE_STORAGE})
endif()

# ############################### Downloading cloud packages #########################################################

include(${CMAKE_CURRENT_SOURCE_DIR}/support/cmake/cloud/download.cmake)

download(
    osg
    ${EXTERNALS_OSG_PATH}
    ${EXTERNALS_OSG_OS_SPECIFIC_PATH}
    ${OSG_PACKAGE_URL})

download(
    osi
    ${EXTERNALS_OSI_PATH}
    ${EXTERNALS_OSI_OS_SPECIFIC_PATH}
    ${OSI_PACKAGE_URL})

download(
    sumo
    ${EXTERNALS_SUMO_PATH}
    ${EXTERNALS_SUMO_OS_SPECIFIC_PATH}
    ${SUMO_PACKAGE_URL})

if(NOT
   (APPLE
    OR MINGW))
    download(
        googletest
        ${EXTERNALS_GOOGLETEST_PATH}
        ${EXTERNALS_GOOGLETEST_OS_SPECIFIC_PATH}
        ${GTEST_PACKAGE_URL})
endif()

download(
    models
    ${RESOURCES_PATH}
    ${MODELS_PATH}
    ${MODELS_PACKAGE_URL})

# ############################### Loading external packages ##########################################################

if(USE_GTEST)
    include(${CMAKE_CURRENT_SOURCE_DIR}/support/cmake/external/gtest.cmake)
    set_gtest_libs()
endif()

if(USE_OSG)
    include(${CMAKE_CURRENT_SOURCE_DIR}/support/cmake/external/osg.cmake)
    set_osg_libs()
endif()

if(USE_OSI)
    include(${CMAKE_CURRENT_SOURCE_DIR}/support/cmake/external/osi.cmake)
    set_osi_libs()
endif()

if(USE_SUMO)
    include(${CMAKE_CURRENT_SOURCE_DIR}/support/cmake/external/sumo.cmake)
    set_sumo_libs()
endif()

# ############################### Compiling targets ##################################################################

add_subdirectory(EnvironmentSimulator)

# ############################### OTHERS #############################################################################

if(NOT
   EXISTS
   "test/OSC-ALKS-scenarios/.git")
    execute_process(
        COMMAND git submodule update --init
        WORKING_DIRECTORY ${CMAKE_CURRENT_SOURCE_DIR})
endif()

# Add variables to global scope, e.g. when esmini is used as submodule
set(EXTERNALS_PUGIXML_PATH
    ${EXTERNALS_PUGIXML_PATH}
    CACHE INTERNAL
          "")
set(EXTERNALS_EXPR_PATH
    ${EXTERNALS_EXPR_PATH}
    CACHE INTERNAL
          "")
