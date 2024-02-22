Setting Up Your OpenAI Account

To use the OpenAI API, you need to have an OpenAI account. Follow these steps to create an account and generate an API key:

1. Go to https://openai.com/api and sign up for an account
2. Once you have created an account, go to https://beta.openai.com/account/api-keys
3. Create a new secret key and save it

Saving Your Credentials

To request the OpenAI API, use your API key and organization name (if applicable). To avoid exposing your API key in your Unity project, save it in your device's local storage.

To do this, follow these steps:

1. Create a folder called .openai in your home directory (e.g. C:User\UserName\ for Windows or ~\ for Linux or Mac)
2. Create a file called auth.json in the .openai folder
3. Add an api_key field and an organization field (if applicable) to the auth.json file and save it
Here is an example of what your auth.json file should look like:

{
    "api_key": "sk-...W6yi",
    "organization": "org-...L7W"
}
![image](https://github.com/shamitahmed/GenAI-matchingGame/assets/62556347/52cf37da-dffa-491a-87cb-54dc62dc7c03)
