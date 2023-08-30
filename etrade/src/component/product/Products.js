import React, { Component } from 'react';
import axios from 'axios';
import { ToastContainer, toast } from 'react-toastify'; // Ekledik
import 'react-toastify/dist/ReactToastify.css';
import './Product.css';


class Products extends Component {
    constructor(props) {
        super(props);
        this.state = {
            products: [],
            //loggedInUser: { id: "guest@example.com", username: 'Guest' }
        };
    }

    componentDidMount() {
        this.fetchProducts();
    }

    fetchProducts = () => {
        axios.get('https://localhost:7203/api/Product/List')
            .then(response => {
                console.log('Products:', response.data);
                this.setState({ products: response.data });
            })
            .catch(error => {
                console.error('API request error:', error);
            });
    };

    handleAddToCart = (product) => {
        const basketId = 1;
        const productId = product.id;
        const amount = 1;
        const dto = { Amount: amount };

        axios.post(`https://localhost:7203/api/BasketDetail/Add?basketId=${basketId}&productId=${productId}`, dto)
            .then(response => {
                console.log('Product added to basket:', response.data);
                this.setState({ basketItems: response.data });
                toast.success('Product added to cart');
            })
            .catch(error => {
                // console.error('API request:', error);
                toast.info('Sepetinizde bu ürün var');
            });
    };

    render() {
        const { products } = this.state;

        return (
            <div>
                <div className="row">
                    {products.map(product => (
                        <div className="col-md-4 mb-4" key={product.id}>
                            <div className="card">
                            <img src={product.photoUrl} alt={product.description} className="card-img-top" />
                                <div className="card-body">
                                    
                                    <h5 className="card-title">{product.description}</h5>
                                    <p  className="card-text">{product.price}₺</p>
                                    <button className="btn btn-primary" onClick={() => this.handleAddToCart(product)}>Add to Cart</button>
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

export default Products;
