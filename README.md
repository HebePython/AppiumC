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

## Starting an Android Emulator (Virtual Device)

To run the tests, you need an Android emulator (virtual device) running. Here are the steps to start one using Android Studio:

1. **Open Android Studio.**
2. Go to **Tools > Device Manager** (or **Tools > AVD Manager** in older versions).
3. Click **Create Device** to add a new virtual device, or select an existing one from the list.
4. Choose a device definition (e.g., Pixel 5, Nexus 7, Tablet, etc.) and click **Next**.
5. Select a system image (e.g., Android 12.0, x86_64) and click **Next**.
6. Review the configuration and click **Finish** to create the device.
7. In the Device Manager/AVD Manager, click the **Play** (▶) button next to your virtual device to start it.
8. Wait for the emulator to fully boot before running your tests.

**Tip:** You can also use the [Emulator VS Code extension](https://marketplace.visualstudio.com/items?itemName=DiemasMichiels.emulate) to launch emulators directly from VS Code after configuration.

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
