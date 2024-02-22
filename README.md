Setting Up Your OpenAI Account

To use the OpenAI API, you need to have an OpenAI account. Follow these steps to create an account and generate an API key:

    Go to https://openai.com/api and sign up for an account
    Once you have created an account, go to https://beta.openai.com/account/api-keys
    Create a new secret key and save it

Saving Your Credentials

To make requests to the OpenAI API, you need to use your API key and organization name (if applicable). To avoid exposing your API key in your Unity project, you can save it in your device's local storage.

To do this, follow these steps:

    Create a folder called .openai in your home directory (e.g. C:User\UserName\ for Windows or ~\ for Linux or Mac)
    Create a file called auth.json in the .openai folder
    Add an api_key field and a organization field (if applicable) to the auth.json file and save it
    Here is an example of what your auth.json file should look like:

{
    "api_key": "sk-...W6yi",
    "organization": "org-...L7W"
}
