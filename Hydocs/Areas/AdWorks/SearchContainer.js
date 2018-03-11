"use strict";

var SearchContainer = React.createClass({
    displayName: "SearchContainer",

    doSearch: function doSearch(queryText) {
        console.log(queryText);
        //get query result
        var queryResult = [];
        this.props.data.forEach(function (person) {
            if (person.name.toLowerCase().indexOf(queryText) != -1) queryResult.push(person);
        });

        this.setState({
            query: queryText,
            filteredData: queryResult
        });
    },
    getInitialState: function getInitialState() {
        return {
            query: '',
            filteredData: this.props.data
        };
    },
    render: function render() {
        return React.createElement(
            "div",
            { className: "InstantBox" },
            React.createElement(
                "h2",
                null,
                "Customers Instant Search"
            ),
            React.createElement(SearchBox, { query: this.state.query, doSearch: this.doSearch }),
            React.createElement(DisplayTable, { data: this.state.filteredData })
        );
    }
});

var tableData;

var SearchBox = React.createClass({
    displayName: "SearchBox",

    doSearch: function doSearch() {
        var elem = ReactDOM.findDOMNode(this); //TKJ
        var query = elem.value; // this is the search text, changed, TKJ
        this.props.doSearch(query);
    },
    render: function render() {
        var _this = this;

        //changed ref assignment here, TKJ
        return React.createElement("input", { type: "text", ref: function (ref) {
                return _this.searchInput = ref;
            }, placeholder: "Search Name", value: this.props.query, onChange: this.doSearch });
    }
});

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
                    person.CustomerKey
                ),
                React.createElement(
                    "td",
                    null,
                    person.FirstName
                ),
                React.createElement(
                    "td",
                    null,
                    person.LastName
                ),
                React.createElement(
                    "td",
                    null,
                    person.EmailAddress
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
                        "ID"
                    ),
                    React.createElement(
                        "th",
                        null,
                        "First Name"
                    ),
                    React.createElement(
                        "th",
                        null,
                        "Last Name"
                    ),
                    React.createElement(
                        "th",
                        null,
                        "Email"
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

function GetAllEmployees() {
    jQuery.support.cors = true;
    $.ajax({
        url: 'http://localhost/api/Customers',
        type: 'GET',
        dataType: 'json',
        success: function success(data) {
            tableData = data;
        },
        error: function error(x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}



