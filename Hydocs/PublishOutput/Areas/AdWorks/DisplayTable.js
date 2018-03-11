"use strict";

var DisplayTable = React.createClass({
    displayName: "DisplayTable",

    render: function render() {
        //making the rows to display
        var rows = [];
        this.props.data.forEach(function (person) {
            rows.push(React.createElement(
                "tr",
                null,
                React.createElement(
                    "td",
                    null,
                    person.name
                ),
                React.createElement(
                    "td",
                    null,
                    person.roll
                )
            ));
        });
        //returning the table
        return React.createElement(
            "table",
            null,
            React.createElement(
                "thead",
                null,
                React.createElement(
                    "tr",
                    null,
                    React.createElement(
                        "th",
                        null,
                        "Name"
                    ),
                    React.createElement(
                        "th",
                        null,
                        "Roll No"
                    )
                )
            ),
            React.createElement(
                "tbody",
                null,
                rows
            )
        );
    }
});

