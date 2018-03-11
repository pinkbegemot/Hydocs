"use strict";

var SearchBox = React.createClass({
    displayName: "SearchBox",

    doSearch: function doSearch() {
        var query = this.refs.searchInput.getDOMNode().value; // this is the search text
        this.props.doSearch(query);
    },
    render: function render() {
        return React.createElement("input", { type: "text", ref: "searchInput", placeholder: "Search Name", value: this.props.query, onChange: this.doSearch });
    }
});

