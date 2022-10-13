import React, { Component } from 'react';

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { users: [], loading: true };
    }

    componentDidMount() {
        this.getUsers();
    }

    static renderUsersTable(users) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Age in 20 years</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map((user, index) =>
                        <tr key={index}>
                            <td>{user.FirstName + ' ' + user.LastName}</td>
                            <td>{user.Age + 20}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
            : App.renderUsersTable(this.state.users);

        return (
            <div>
                <h1 id="tabelLabel" >Users</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async getUsers() {
        const response = await fetch('Users');
        const data = await response.json();
        this.setState({ users: data, loading: false });
    }
}
