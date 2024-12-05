# Prop It Up

Create a component called `PersonCard` that accepts the following props:

1. `firstName`
2. `lastName`
3. `age`
4. `hairColor`

Then, display four `PersonCard` components that show four different people, using props.

** This will not require a form for data input. Use static information passed through component attributes (props).

![Diagram](Diagram.png)



NOTE: You can use a component repeatedly and use different values each time. Example:
```
function App() {
    return (
        <div className="App">
            <SaleItem prop1={ value1 } />
            <SaleItem prop1={ value2 } />
            <SaleItem prop1={ value3 } />
        </div>
    );
}
```

## Requirements:
- Create a new component called PersonCard to display a single person's set of information using props for values
- Call the Person component repeatedly using different prop values to display 4 unique sets of information

