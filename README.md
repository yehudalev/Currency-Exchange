# Currency-Exchange

### A GUI tool for currency traders (Forex Trading) that allows viewing current currency rates Near Real Time (NRT), displaying historical currency rates, and performing currency conversions from one currency to another

This projects use the https://currencylayer.com/ API

In the member-class `key` in class `Dal_with_DB` (`Currency-Exchange/DAL/Dal_with_DB.cs`) you need to assign the key value provided from currencylayer api.

Download the UI controls package form WPF https://www.syncfusion.com/

* The system will display the status of the currencies you will receive from currencylayer.

* The system will periodically save the data in a local database.

* You can search for and display a current or historical currency rate for a period.

Implemented in 3-layer-model as a division architecture between the layers:
```
DAL (data access layer)
```
```
PL (presentation Layer)
```
```
BL (business Layer)
```
```
BE (business entities) as a cross-layer
```
```
PL (The presentation layer) I implemented in WPF (a technology to create UI in Windows system).
I used the MVVM architecture to decouple the logic layer, user interface and data.
```
