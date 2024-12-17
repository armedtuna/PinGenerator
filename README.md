# Code Challenge

I was given a code challenge to create a pin generator with certain rules. I completed it, received some feedback and thought that that was the end of it.

A little time afterward, I started thinking about it some more, especially in terms of Single Responsibility, Test Driven Development (TDD), and KISS principles. The more I thought about it, the more I started realising quite a few things.

Part of that was wondering more about KISS Principles. I used to think that KISS Principles meant the least amount of classes, with where necessary new (private) methods for different responsibilities. However, there was always a niggle when thinking about testing those private methods -- the usual resolution was to either make those methods public, or to extract a helper class, and while that "worked" there was always that niggle.

I started and am still wondering about where the line between Single Responsibility and KISS Principles are, and this code challenge seems to be a very interesting example of thinking about that, and also addressing the above-mentioned niggle.

# Part 2

## Single Responsibility

The original classes have been split into multiple responsibilities. Now that the responsibilities are simpler they are also easier to test, and unit and integration tests have been added.

A little bit of "fun" was also added, because it is debatable how much value the Digit Rules class adds. It's certainly more flexible, but given the needs of this project, it could have been one class only.

It was a little bit eye-opening to see how simple unit tests can be for single responsibility classes. The unit tests are so simple, they're almost disappointing. That raises two very interesting and valuable points:

- As stated below, the unit tests uncovered bugs in the code.
- Adding unit tests for single responsibility code doesn't take that much time.

PS While adding the tests, so minor bugs were discovered, but these were fixed before the first commit, because the code and tests were written at the same time -- only committed separately to keep the commits smaller.

# Builder

Added a simple diagram to show how the interfaces relate to each other. As I did that I discovered that there was an unnecessary dependency (and I removed that).

The goal of the diagram was also to be able to see the overall design. I'm not fully happy that both Pin Generator and No-Incremental Digits Rule depending on Digit Provider. I briefly tried changing the No-Incremental Digits Rule to have delegates instead of a dependency, but that didn't seem an improvement.

In the end it seemed best to add a builder to set up the Pin Generator and its dependencies. I also added a test for the builder, but I'm unsure how to test that the private dependencies were created correctly. Thoughts of reflection came up, but I'm not keen on heading down that path. So I concluded that being able to run the builder's Pin Generator without exception is "acceptable".