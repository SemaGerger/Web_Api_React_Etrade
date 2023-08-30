import React, { Component } from 'react';
import axios from 'axios';

class AddProduct extends Component {
    constructor(props) {
        super(props);
        this.state = {
            description: '',
            categoryId: '',
            supplierId: '',
            unitPrice: 0,
            vat: 0,
            PhotoUrl: '',
            categories: [], 
            suppliers: []   
        };
    }

    componentDidMount() {
        this.fetchCategoriesAndSuppliers();
    }

    fetchCategoriesAndSuppliers() {
        axios.get('https://localhost:7203/api/Category/List')
            .then(response => {
                this.setState({ categories: response.data });
            })
            .catch(error => {
                console.error('Category API request error:', error);
            });

        axios.get('https://localhost:7203/api/Supplier/List')
            .then(response => {
                this.setState({ suppliers: response.data });
            })
            .catch(error => {
                console.error('Supplier API request error:', error);
            });
    }

    handleInputChange = event => {
        const { name, value } = event.target;
        this.setState({ [name]: value });
    }

    handleSubmit = event => {
        event.preventDefault();
        const { description, categoryId, supplierId, unitPrice, vat, PhotoUrl } = this.state;

        const newProduct = {
            description,
            categoryId,
            supplierId,
            unitPrice,
            vat,
            PhotoUrl
        };

        axios.post('https://localhost:7203/api/Product/Create', newProduct)
            .then(response => {
                console.log('Product added:', response.data);

                
                // alert('Product added successfully!');
                this.setState({
                    description: '',
                    categoryId: '',
                    supplierId: '',
                    unitPrice: 0,
                    vat: 0,
                    PhotoUrl: ''
                });
            })
            .catch(error => {
                // console.error('API request error:', error);
            });
    }

    render() {
        const { description, categoryId, supplierId, unitPrice, vat, PhotoUrl, categories, suppliers } = this.state;

        return (
            <div>
                <h2>Add Product</h2>
                <form onSubmit={this.handleSubmit}>
                    <div className="form-group">
                        <label>Description:</label>
                        <input
                            type="text"
                            name="description"
                            value={description}
                            onChange={this.handleInputChange}
                            className="form-control"
                            required
                        />
                    </div>
                    <div className="form-group">
                        <label>Category:</label>
                        <select
                            name="categoryId"
                            value={categoryId}
                            onChange={this.handleInputChange}
                            className="form-control"
                            required
                        >
                            <option value="">Select a category</option>
                            {categories.map(category => (
                                <option key={category.id} value={category.id}>
                                    {category.description}
                                </option>
                            ))}
                        </select>
                    </div>
                    <div className="form-group">
                        <label>Supplier:</label>
                        <select
                            name="supplierId"
                            value={supplierId}
                            onChange={this.handleInputChange}
                            className="form-control"
                            required
                        >
                            <option value="">Select a supplier</option>
                            {suppliers.map(supplier => (
                                <option key={supplier.id} value={supplier.id}>{supplier.description}</option>
                            ))}
                        </select>
                    </div>
                    <div className="form-group">
                        <label>Unit Price:</label>
                        <input
                            type="number"
                            name="unitPrice"
                            value={unitPrice}
                            onChange={this.handleInputChange}
                            className="form-control"
                            required
                        />
                    </div>
                    <div className="form-group">
                        <label>VAT:</label>
                        <input
                            type="number"
                            name="vat"
                            value={vat}
                            onChange={this.handleInputChange}
                            className="form-control"
                            required
                        />
                    </div>
                    <div className="form-group">
                        <label>Photo URL:</label>
                        <input
                            type="text"
                            name="PhotoUrl"
                            value={PhotoUrl}
                            onChange={this.handleInputChange}
                            className="form-control"
                        />
                    </div>
                    <button type="submit" className="btn btn-primary">Add Product</button>
                </form>
             
            </div>
        );
    }
}

export default AddProduct;
