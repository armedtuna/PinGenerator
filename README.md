# Code Challenge

I was given a code challenge to create a pin generator with certain rules. I completed it, received some feedback and thought that that was the end of it.

A little time afterward, I started thinking about it some more, especially in terms of Single Responsibility, Test Driven Development (TDD), and KISS principles. The more I thought about it, the more I started realising quite a few things.

Part of that was wondering more about KISS Principles. I used to think that KISS Principles meant the least amount of classes, with where necessary new (private) methods for different responsibilities. However, there was always a niggle when thinking about testing those private methods -- the usual resolution was to either make those methods public, or to extract a helper class, and while that "worked" there was always that niggle.

I started and am still wondering about where the line between Single Responsibility and KISS Principles are, and this code challenge seems to be a very interesting example of thinking about that, and also addressing the above-mentioned niggle.

todo: update solution readme re "extract responsibility commit"