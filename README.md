# Medico

## Short Description

A small piece of Annoy-Ware that is designed to annoy the user until they have taken their medication.

This repo is a .NET Core re-implementation of the original repo, which can be found [here](https://github.com/GaProgMan/Medico)

## Project Goal

Fulfil the final wish of a close friend of mine who passed away, at the age of 32, shortly before Christmas 2013. He'd lamented on the fact that there weren't any apps that could help him to take all of his prescribes medications on time.

We'd discussed the idea in great detail during (what would become) his final summer. His medication regimen was quite strict during the final year of his life, and he would follow this procedure everyday:

* Take his first medication shortly after waking
* Create a series of alarms on his mobile devices, one for each the doses of his medication
* Nap until it was time to take his medication (the alarm would wake him)

All of his medication was time based, so he would have to set each of the alarms at the beginning of the day - MANUALLY. What he wanted was an app that would set all of the alarms for him when he took his first dose in the morning. Should his miss or delay a dose, the later alarms would be put on hold until he took his allotted dose, then all alarms based after that one would cascade AUTOMATICALLY.

I will consider this repository 100% successful if only one person is helped by it. Also, should this code base help convince developers to create a similar application, then this will be taken as 100% success for this repository.

## Code of Conduct
ClacksMiddleware has a Code of Conduct which all contributors, maintainers and forkers must adhere to. When contributing, maintaining, forking or in any other way changing the code presented in this repository, all users must agree to this Code of Conduct.

See [Code of Conduct.md](Code-of-Conduct.md) for details.

## Technology Used

The application will be written using C# using .NET Core.