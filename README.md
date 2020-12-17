# FM: Systems Software Engineer Coding Exercise
Make sure you read this document carefully and follow the guidelines we've provided.

## Context
This exercise demonstrates to you some of the technologies being utilized at FM: Systems. It will also demonstrate to the development team how you approach a solution given liberal implementation guidelines. This exercise is designed to be completed under four hours.

## Requirements

### Requirement 1:
Using .NET Core, create an API that exposes a collection of the following cities:
- Phoenix, AZ
- Raleigh, NC
- Saint John, NB (Canada)
- San Diego, CA 

### Requirement 2:
Create a .NET Core unit test project to test this API action.

### Requirement 3:
Using any web technologies you'd like, display the list of cities in a drop-down list. The list should be populated via a request to the city collection API that you created. The UI design should be simple and take minimal time to develop.

### Requirement 4:
Selecting a city from the drop-down needs to trigger a call out to the [DarkSky API](https://darksky.net/dev) and retrieve the weather for the selected city from July 4, 2018 at exactly noon local time. On the screen display the noon current summary description (example: Mostly Sunny), temperature (example: 88.81), and UV index (example: 5).

> Note: The Dark Sky API [doesn't enable CORS](https://darksky.net/dev/docs/faq#cross-origin). Handle this case as you see fit.

### Bonus
- Write clear documentation on how the app was designed and how to run the code.
- Provide an online demo of the application.
- Describe optimization opportunities when you conclude.

## What matters in this exercise
We're interested in your method and how you approach the problem just as much as we're interested in the end result. Use any libraries/packages you would normally use if this were a real production application.
> Note: we're interested in your code & the way you solve the problem, not how well you can use a particular library or feature.

## What you should strive for
- Good use of current .NET design patterns and performance best practices.
- Solid testing approach.
- Extensible code.
- Able to explain your design decisions.
- Demonstrate good git best practices.

## Q&A

> Where should I send back the result when I'm done?

Fork this repo and send us a pull request when you've completed the exercise. **Do not commit your Dark Sky API secret key.**

> What if I have a question?

Create a new issue in this repo and a team member will get back to you ASAP.
