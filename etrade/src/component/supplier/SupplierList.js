// SupplierList.js

import React, { useState, useEffect } from 'react';

function SupplierList() {
    const [suppliers, setSuppliers] = useState([]);

    useEffect(() => {
        fetchSuppliers();
    }, []);

    const fetchSuppliers = async () => {
        try {
            const response = await fetch('https://localhost:7203/api/Supplier/List');
            const data = await response.json();
            setSuppliers(data);
        } catch (error) {
            console.error('Hata:', error);
        }
    };



    return (
        <>
  
    <h2>Suppliers List</h2>
            <div>
                {suppliers.map((supplier, index) => (
                    <p key={supplier.id}>
                        {index + 1}.
                        {supplier.description}
                    </p>
                ))}
            </div>
        </>
    );
}

export default SupplierList;
