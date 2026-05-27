import { useEffect, useState } from "react";
import type { User } from "../types/responses/User";
import { getUsers } from "../services/UserService";

const UserList = () => {
    const [users, setUsers] = useState<User[]>([]);

    useEffect(
        () => {
            getUsers().then((data) => setUsers(data)).catch(err => console.error('could not get users' + err));
        }
        , []);
    return (
        <div>
            <h1>List of Users</h1>
            {users.map((u) => (
                <div key={u.ExternalId}>
                    <p>UserName: {u.Username}</p>
                    <p>Name: {u.Name}</p>
                    <p>Email: {u.Email}</p>
                    <p>Id: {u.ExternalId}</p>
                    <hr />
                </div>))
            }
        </div >
    );
}

export default UserList