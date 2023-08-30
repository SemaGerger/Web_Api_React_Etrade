import React, { Component } from 'react';
import axios from 'axios';
import './ProductCart.css';
//import BasketDetail from '../basket/BasketDetail';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

class ProductCart extends Component {
    constructor(props) {
        super(props);
        this.state = {
            products: []
        };
    }

    componentDidMount() {
        axios.get('https://localhost:7203/api/Product/List')
            .then(response => {
                console.log('Products:', response.data);
                this.setState({ products: response.data });
            })
            .catch(error => {
                console.error('API request error:', error);
            });
    }

    handleAddToCart = (product) => {
        // Burada sepete ekleme işlemlerini gerçekleştirebilirsiniz
        // Örneğin: Sepet durumunu güncelleme, ürünü sepete eklemek için API çağrısı yapma, vb.
        // Ardından, aşağıdaki gibi bir bildirim gösterebilirsiniz
        toast.success(`Product "${product.description}" added to cart!`);
    };

    render() {
        const { products } = this.state;

        return (
            <div>
                <div className="row">
                    {products.map(product => (
                        <div className="col-md-4 mb-4" key={product.id}>
                            <div className="card">
                                <div className="card-body">
                                    <img src={product.photoUrl} alt={product.description} className="img-fluid" />
                                    <h3>{product.description}</h3>
                                    <p>{product.price}₺ </p>
                                    <button onClick={() => this.handleAddToCart(product)}>Add to Cart</button>
                                </div>
                            </div>
                        </div>
                    ))}
                </div>
                <ToastContainer />
            </div>
        );
    }
}

export default ProductCart;
