# RestAPIGetPostTestProject
In this project I created an automated test that tests various calls to a free Rest API online (https://jsonplaceholder.typicode.com)

The test consists of many parts each testing differnt parts, such as getting users from the API, deserializing them and parsing them to check their correctness, as well as posting posts and making sure everything works properly.

Structure
------------------
There is one test file containing the test, and there is an ApiManager class containig general get and post actions to the api, as well as other util classes and models for the user data present on the website api.
