# language: en

Feature: EasyLaserApp
  UI automation for Easy-Laser XT Alignment app

  # This scenario checks that clickable elements are found and printed
  Scenario: Print all clickable elements
    Given the app is started
    When I print all clickable elements
    Then clickable elements should be listed in the output

  # This scenario launches the Easy-Laser XT Alignment app
  Scenario: Launch Easy-Laser XT Alignment app
    Given the app is started
    When I launch the Easy-Laser XT Alignment app
    Then the app should be launched successfully

  # This scenario checks that the App Has started successfully
  Scenario: Easy-Laser XT Aligntment app has started
    Given The app has started
    When I inspect the screen
    Then the app interface should be visible
  
