'use strict';

var CONTRIBUTORS;
var MAX_CONTRIBUTORS = 100;
var ASYNC_DELAY = 500;

var CustomersSelect = React.createClass({
    displayName: 'Customers',

    getInitialState: function getInitialState() {
        return {
            multi: true,
            value: ""
        };
    },
    onChange: function onChange(value) {
        this.setState({
            value: value
        });
    },
    switchToMulti: function switchToMulti() {
        this.setState({
            multi: true,
            value: [this.state.value]
        });
    },
    switchToSingle: function switchToSingle() {
        this.setState({
            multi: false,
            value: this.state.value[0]
        });
    },
    getContributors: function getContributors(input, callback) {
        input = input.toLowerCase();
        var options = CONTRIBUTORS.filter(function (i) {
            return i.github.substr(0, input.length) === input;
        });
        var data = {
            options: options.slice(0, MAX_CONTRIBUTORS),
            complete: options.length <= MAX_CONTRIBUTORS
        };
        setTimeout(function () {
            callback(null, data);
        }, ASYNC_DELAY);
    },
    gotoContributor: function gotoContributor(value, event) {
        window.open('//localhost/hydocs/AdWorks/customersmv/Details/' + value.key);
    },
    render: function render() {
        return React.createElement(
            'div',
            { className: 'section' },
            React.createElement(
                'h3',
                { className: 'section-heading' },
                'Select Customers'
            ),
            React.createElement(Select.Async, { multi: this.state.multi, value: this.state.value, onChange: this.onChange, onValueClick: this.gotoContributor, valueKey: 'github', labelKey: 'name', loadOptions: this.getContributors }),
            React.createElement(
                'div',
                { className: 'checkbox-list' },
                React.createElement(
                    'label',
                    { className: 'checkbox' },
                    React.createElement('input', { type: 'radio', className: 'checkbox-control', checked: this.state.multi, onChange: this.switchToMulti }),
                    React.createElement(
                        'span',
                        { className: 'checkbox-label' },
                        'Multiselect'
                    )
                ),
                React.createElement(
                    'label',
                    { className: 'checkbox' },
                    React.createElement('input', { type: 'radio', className: 'checkbox-control', checked: !this.state.multi, onChange: this.switchToSingle }),
                    React.createElement(
                        'span',
                        { className: 'checkbox-label' },
                        'Single Value'
                    )
                )
            ),
            React.createElement(
                'div',
                { className: 'hint' },
                'This example implements custom label and value properties, async options and opens the github profiles in a new window when values are clicked'
            )
        );
    }
});
exports = CustomersSelect;

