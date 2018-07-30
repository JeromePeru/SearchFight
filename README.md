# SearchFight

To determine the popularity of programming languages on the internet, this application queries search engines and compares how many results they return, for example:
 
    C:\> searchfight.exe .net java
    .net: Google: 4450000000 MSN Search: 12354420
    java: Google: 966000000 MSN Search: 94381485
    Google winner: .net
    MSN Search winner: java
    Total winner: .net

## Architecture

The application is developed around a Managed Extensibility Framework (MEF) architecture : the list of Search Engine is loaded when the application is started. All search engines are stored in the "Plugins" folder.
There is no need to compile the application to add a new Search Engine. The interface is describing the class to implement.


## Getting started

*SearchFight.exe .net java*
The application is able to receive a **variable amount of words**
The application supports **quotation marks** to allow searching for terms with spaces (e.g. searchfight.exe “java script”)

### Configuration

The config file contains the required parameters to use Search engine services. 

### Provided Search Engines

The application is provided with 2 search engines : 
 - ***Google Custom Search***. This solution is limited to 100 queries per day. [(More information here)](https://developers.google.com/custom-search/json-api/v1/overview "(More information here)")
 - ***Bing Custom Search***. [(More information here)](https://azure.microsoft.com/en-US/try/cognitive-services "(More information here)")
 
## License

This project is licensed under the MIT License.

