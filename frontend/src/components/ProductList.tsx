import { useEffect, useState } from "react";
import { getProducts } from "../services/ProductService";
import type { Product } from "../types/responses/Product";

const ProductList = () => {
    const [products, setProducts] = useState<Product[]>([]);

    useEffect(
        () => {
            getProducts().then((data) => setProducts(data)).catch(err => console.error('could not get products' + err));
        }
        , []);
    return (
        <div>
            <h1>List of Products</h1>
            {products.map((p) => (
                <div key={p.productResourceId}>
                    <p>Name: {p.name}</p>
                    <p>Id: {p.productResourceId}</p>
                    <hr />
                </div>))
            }
        </div >
    );
}

export default ProductList