
var CONTRIBUTORS;
const MAX_CONTRIBUTORS = 100;
const ASYNC_DELAY = 500;

var CustomersSelect =React.createClass({
    displayName: 'Customers',
 
    getInitialState() {
        return {
            multi: true,
            value:"",
        };
    },
    onChange(value) {
        this.setState({
            value: value,
        });
    },
    switchToMulti() {
        this.setState({
            multi: true,
            value: [this.state.value],
        });
    },
    switchToSingle() {
        this.setState({
            multi: false,
            value: this.state.value[0],
        });
    },
    getContributors(input, callback) {
        input = input.toLowerCase();
        var options = CONTRIBUTORS.filter(i => {
            return i.github.substr(0, input.length) === input;
        });
        var data = {
            options: options.slice(0, MAX_CONTRIBUTORS),
            complete: options.length <= MAX_CONTRIBUTORS,
        };
        setTimeout(function () {
            callback(null, data);
        }, ASYNC_DELAY);
    },
    gotoContributor(value, event) {
        window.open('//localhost/hydocs/AdWorks/customersmv/Details/' + value.key);
    },

    componentWillMount: function () {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function () {
            var response = JSON.parse(xhr.responseText);
            CONTRIBUTORS = response;
            this.setState({ data: response.result });
        }.bind(this);
        xhr.send();
        //alert('Data fetched');
    },
    render() {
        return (
            <div className="section">
                <h3 className="section-heading">Select Customers</h3>
                <Select.Async multi={this.state.multi} value={this.state.value} onChange={this.onChange} onValueClick={this.gotoContributor} valueKey="github" labelKey="name" loadOptions={this.getContributors} />
                <div className="checkbox-list">
                    <label className="checkbox">
                        <input type="radio" className="checkbox-control" checked={this.state.multi} onChange={this.switchToMulti} />
                        <span className="checkbox-label">Multiselect</span>
                    </label>
                    <label className="checkbox">
                        <input type="radio" className="checkbox-control" checked={!this.state.multi} onChange={this.switchToSingle} />
                        <span className="checkbox-label">Single Value</span>
                    </label>
                </div>
                <div className="hint">This example implements custom label and value properties, async options and opens the github profiles in a new window when values are clicked</div>
            </div>
        );
    }
});
