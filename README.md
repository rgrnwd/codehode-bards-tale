# bards-tale
A story telling application

## Building the application
You'll need to have dotnet core installed on your machine. 
You can find the SDK at: `https://download.microsoft.com/download/2/9/3/293BC432-348C-4D1C-B628-5AC8AB7FA162/dotnet-sdk-2.1.3-osx-gs-x64.pkg`
Once that's installed, you can try to run the command `dotnet --version` in your terminal.
CD into the project folder `BardsTale`
Run the command `dotnet build`

## Running the application
Run the command `dotnet run`
The application will prompt you to enter five words - actually there is no limit on the number of words you can provide 
and it will try to make use of them all. Words should be separated by spaces.

## Running the tests
CD into the test project folder `BardsTale.Tests`
Run the command `dotnet test`

## About the design
Bard -the "brain" of the application / composer of the story, who uses the memory and imagination to identify the words 
entered and turn them into a story.
Imagination - it randomises names / characters / events based on known words in the "memory"
Memory - uses a few dictionary listings (Available under Resources) to categorise words
MeaningParser - tries to turn the user's input to figure out what to tell a story about
WordProcessor - responsible for processing user input and categorise them into words (from Memory)
The StoryContext is passed around from the Bard to the different parts of the brain to come up with a story