# What is execution context
execution context defines context which your code runs. The system passes the execution context when an even occurs on a form or grid. you can use it to perform various tasks such as determining the formContext or gridContext or managing the save event

so we can say **executionContext** is the Object your system pass to the JS Library once an Event happen on the screen like (OnLoad) and with it JS can access a lot of things on your screen like the data and fields that the user see `it has 3 Important Methods you should know:`

- `getFormContext()`: it gives you access to fully control the form (read and write data, hide fields or show notifications for user)
- `getEventSource()`: it return the source or field that cause the code to run "useful for OnChange Events to know which field changed"
- `getEventArgs()`: it contain details of event itself (it can be used to prevent form from saving in case validation failed for ex)

## getFormContext() objects
- data
- ui => used with user interface
- getAttribute => it allow us to getvalue and setvalue
- getControl
### getFormContext().data objects
from it you can access
- attributes
- entity 
  - attributes
  - save method
- Process
  - stages
  - steps
it also contain some methods we can use like
- addOnLoad and removeOnLoad
- getIsDirty
- isValid
- refresh
- save
### getFormContext().ui object
- formSelector.items
- navigation.items
- controls
- process
- quickForms
- tabs
  - tabs.sections
it also contain some methods we can use like
- addOnLoad and removeOnLoad
- close
- getFormType - returns:
  - 0 = undefined,
  - 1 = Create,
  - 2 = Update,
  - 3 = Read Only,
  - 4 = Disabled,
  - 6 = Bulk Edit.
- getViewPortHeight and getViewPortWidth
- setFormEntityName
- setFormNotification(message, level, uniqueID)
- clearFormNotification(uniqueID)
### getFormContext().getControl object
it contain some methods you can use like
- addNotification , clearNotification
- getAttribute
- getControlType
- getDisabled, setDisabled
- getLabel, setLabel
- getName
- getOutput
- getParent
- getVisible, setVisible
- setFocus