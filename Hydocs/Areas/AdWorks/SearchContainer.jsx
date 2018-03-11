
var SearchContainer = React.createClass({
   
    doSearch:function(queryText){
        console.log(queryText)
        //get query result
        var queryResult = [];
        if(queryText !=='') //TKJ changed
        tableData.forEach(function(person){
            if (person.FirstName.toLowerCase().indexOf(queryText) != -1 || person.LastName.toLowerCase().indexOf(queryText) != -1 )
            queryResult.push(person);
        });
        this.setState({
            query:queryText,
            filteredData: queryResult
        })
    },
    getInitialState: function () {
       return {
            query:'',
            filteredData: this.props.data
        }
    },

    componentWillMount: function () {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function () {
            var response = JSON.parse(xhr.responseText);
            tableData = response;
            this.setState({ data: response.result });
           }.bind(this);
        xhr.send();
        //alert('Data fetched');
},
   
   
   componentWillUnmount:function () {
        this.serverRequest.abort();
    },

   render: function () {
    
        return (
            <div className="row">
                <h4>Try instant search</h4>
                <SearchBox query={this.state.query} doSearch={this.doSearch} />
                <p></p>
                <DisplayTable data={this.state.filteredData}/>
            </div>
        );
    }
});

var tableData;

var SearchBox = React.createClass({
    componentDidMount() { //TKJ, focus added
        this.searchInput.focus();
    },
    doSearch: function () {
        var elem = ReactDOM.findDOMNode(this); //TKJ
        var query = elem.value; // this is the search text, changed, TKJ
        this.props.doSearch(query);
    },
    render: function () {
      //changed ref assignment here, TKJ
        return <input type="text" ref={(ref) => this.searchInput = ref} placeholder="Search name" value={this.props.query} onChange={this.doSearch} />
    }
});

var DisplayTable = React.createClass({
   
    render: function () {
        if (!this.props.data || this.props.query==='' )
            return <div />;

        //making the list [rows] to display
        var rows = [];
        this.props.data.forEach(function (person) {
            var ref = `/hydocs/adworks/customersmv/details/${person.CustomerKey}`;
            rows.push(<tr><td><a  class = 'link' href={ref}>{person.FirstName} {person.LastName}</a></td></tr >)
        });
        //returning the table similar to a dropdown list 
        return ( 
            <table className='list-group'>
              <tbody>{rows}</tbody>
            </table>
        );
    }
});


