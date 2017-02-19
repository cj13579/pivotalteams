# pivotalteams

_pivotalteams_ allows you to connect a Pivotal Tracker project and a Microsoft Teams channel. It's a C# script that is designed to be deployed as an Azure Function App.

Currently _pivotalteams_ will look for the following Pivotal Tracker activities but you can add more just by adding more if blocks to the code:

- Story added
- Story started
- Story finished
- Story delivered
- Story accepted
- Story rejected

## Deployment

1. Create an _Incoming Webhook_ connector in your channel in Microsoft Teams and copy the URL that you're given.
1. Create a new Function App from the Azure Portal and paste the code from `pivotalteams.csx`
1. Create an environment variable called `TEAMS_URL` and set the value to be the URL from the previosly created Microsoft Teams connector.

## Contribute

Feel free to fork and submit pull requests or submit issues.

## License 

pivotalteams is available under the MIT license.