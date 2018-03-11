'use strict';
var SearchContainer = React.createClass({
 
    displayName: 'SearchContainer',

    doSearch: function doSearch(queryText) {
        console.log(queryText);
        //get query result
        var queryResult = [];
        this.props = this.props.bind(this); //added by TKJ, otherwise 'undefined' error
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
            'div',
            { className: 'InstantBox' },
            React.createElement(
                'h2',
                null,
                'Customers Instant Search'
            ),
            React.createElement(SearchBox, { query: this.state.query, doSearch: this.doSearch }),
            React.createElement(DisplayTable, { data: this.state.filteredData })
        );
    }
});

//ReactDOM.render(React.createElement(SearchContainer, { data: tableData }), document.getElementById('search'));

var tableData = [{
    name: 'Paul Shan',
    roll: '001'
}, {
    name: 'John Doe',
    roll: '002'
}, {
    name: 'Sachin Tendulkar',
    roll: '003'
}];

var SearchBox = React.createClass({
    displayName: 'SearchBox',
    doSearch: function doSearch() {
       var self = this;
        var query = this.ref.searchInput.getDOMNode().value; // this is the search text
        self.props.doSearch(query);
    },
    render: function render() {
       // <input type="text" ref={(ref) => this.myTextInput = ref} />
        return React.createElement('input', { type: 'text', ref: 'searchInput', placeholder: 'Search Name', value: this.props.query, onChange: this.doSearch });

        //return React.createElement('input', { type: 'text', ref: 'searchInput', placeholder: 'Search Name', value: this.props.query, onChange: this.doSearch });
    }
});

var DisplayTable = React.createClass({
    displayName: 'DisplayTable',

    render: function render() {
        //making the rows to display
        var rows = [];
        this.props.data.forEach(function (person) {
            rows.push(React.createElement(
                'tr',
                null,
                React.createElement(
                    'td',
                    null,
                    person.name
                ),
                React.createElement(
                    'td',
                    null,
                    person.roll
                )
            ));
        });
        //returning the table
        return React.createElement(
            'table',
            null,
            React.createElement(
                'thead',
                null,
                React.createElement(
                    'tr',
                    null,
                    React.createElement(
                        'th',
                        null,
                        'Name'
                    ),
                    React.createElement(
                        'th',
                        null,
                        'Roll No'
                    )
                )
            ),
            React.createElement(
                'tbody',
                null,
                rows
            )
        );
    }
});

