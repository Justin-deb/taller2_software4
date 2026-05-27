import { Link } from "react-router-dom"

export const HomePage = () => {
    return (
        <div>
            <h1>Welcome to the store catalogue</h1>
            <h3>What would you like to do next</h3>

            <span>
                <Link to='/products'>Products</Link>
                <Link to='/users'>Users</Link>
            </span>
        </div>
    )
}
