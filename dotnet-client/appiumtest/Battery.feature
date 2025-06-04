Feature: Battery Settings

  Scenario: Open Battery Settings
    Given the Android Settings app is open
    When I tap on "Battery"
    Then the Battery screen should be displayed
