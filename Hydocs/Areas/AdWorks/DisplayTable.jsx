
var DisplayTable = React.createClass({
    render:function(){
        //making the rows to display
        var rows=[];
        this.props.data.forEach(function(person) {
        rows.push(<tr><td>{person.name}</td><td>{person.roll}</td></tr>)
        });
        //returning the table
        return(
             <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Roll No</th>
                    </tr>
                </thead>
                <tbody>{rows}</tbody>
            </table>
        );
    }
});
