# AppiumC UI Automation Project

This project contains UI automation tests for an Android app using Appium, C#, and NUnit. It is designed to automate and verify UI interactions, including coordinate-based tapping for custom-drawn views.

## Prerequisites

- **.NET SDK** (version 7.0 or 8.0 recommended)
- **Android Studio** (for Android SDK, emulator, and AVD management)
- **Android SDK** (ensure `ANDROID_HOME` or `ANDROID_SDK_ROOT` is set)
- **Appium Server** (v2.x recommended)
- **Node.js** (for Appium installation)
- **Java JDK** (for Android tools)
- **Visual Studio Code** (recommended for editing and running tests)
- **NuGet packages:**
  - Appium.WebDriver
  - NUnit
  - NUnit3TestAdapter
  - Selenium.WebDriver

## Installation & Setup

1. **Clone the repository:**
   ```sh
   git clone https://github.com/<yourusername>/AppiumC.git
   cd AppiumC/dotnet-client/appiumtest
   ```

2. **Install .NET SDK:**
   - Download and install from https://dotnet.microsoft.com/download
   - Verify with:
     ```sh
     dotnet --version
     ```

3. **Install Node.js:**
   - Download and install from https://nodejs.org/
   - Verify with:
     ```sh
     node --version
     ```

4. **Install Appium globally:**
   ```sh
   npm install -g appium
   ```
   - Start Appium server:
     ```sh
     appium
     ```

5. **Install Android Studio and SDK:**
   - Download from https://developer.android.com/studio
   - Create at least one Android Virtual Device (AVD) via AVD Manager.
   - Ensure `ANDROID_HOME` or `ANDROID_SDK_ROOT` is set in your environment variables.

6. **Install Java JDK:**
   - Download from https://adoptopenjdk.net/ or https://www.oracle.com/java/technologies/downloads/
   - Set `JAVA_HOME` environment variable.

7. **Restore NuGet packages:**
   ```sh
   dotnet restore
   ```

8. **Build the project:**
   ```sh
   dotnet build
   ```

9. **Run the tests:**
   ```sh
   dotnet test
   ```

## SpecFlow (BDD) Support

This project uses [SpecFlow](https://specflow.org/) for Behavior-Driven Development (BDD) style tests. SpecFlow allows you to write tests in Gherkin syntax (Given/When/Then) in `.feature` files, which are mapped to C# step definitions.

### SpecFlow Dependencies
To use SpecFlow, you must install the following NuGet packages:
- SpecFlow
- SpecFlow.NUnit
- SpecFlow.Tools.MsBuild.Generation

**Important:**
You must run the following commands from inside the `dotnet-client/appiumtest` folder:

```powershell
cd dotnet-client/appiumtest

dotnet add package SpecFlow
```

```powershell
dotnet add package SpecFlow.NUnit
```

```powershell
dotnet add package SpecFlow.Tools.MsBuild.Generation
```

### How SpecFlow Works
- Write your scenarios in `.feature` files using Gherkin syntax.
- Implement step definitions in C# classes with `[Binding]` attribute.
- Build the project (`dotnet build`) to generate code-behind files for the features.
- Run your tests with `dotnet test`.

Example SpecFlow scenario:
```gherkin
Scenario: Print all clickable elements
  Given the app is started
  When I print all clickable elements
  Then clickable elements should be listed in the output
```

See the `EasyLaserApp.feature` and `EasyLaserAppSteps.cs` files for working examples.

## Notes
- Update the Appium driver capabilities in `exampletest.cs` as needed for your app under test.
- For coordinate-based tests, ensure the emulator/device resolution matches your test assumptions.
- You may need to adjust the Appium server URL or device name in the test setup.

## Troubleshooting
- Make sure the Appium server is running before executing tests.
- Ensure the emulator or device is started and visible to `adb`.
- If you encounter dependency issues, run `dotnet restore` and ensure all NuGet packages are installed.

## License
MIT License
