//function splits an order amount between n people/recipients as evenly as possible (actually a pretty cool script)

function splitOrder(recipients, ord) {
    let remainder = ord%recipients;
    //greatest common factor
    let GCF = Math.floor(ord/recipients);
    
    //each sub will be roughly the GCF + remainder divided by the number of recipients
    //for un even splits sumSubs - ord != 0
    let sub = parseFloat((GCF + (remainder/recipients)).toFixed(2));
    
    //store the each sub in an array
    let subs = [];
    for(let i = 0; i < recipients; i++) {
        subs.push(sub);
    }
    //console.log(subs);

    //sum the subs
    let sumSubs = 0;
    for(let i = 0; i < recipients; i++){
        sumSubs = sumSubs + subs[i];
    }
    sumSubs = parseFloat(sumSubs.toFixed(2));
    //console.log(sumSubs);

    //get difference between sum of the subs and order total
    let difference = parseFloat((sumSubs - ord).toFixed(2));
    //console.log(Math.abs(difference));

    //check if diff is bigger than 0.01 then split the change up evenly as possible between subs else add or subtract change from just 1 (one) sub
    if(Math.abs(difference) > 0.01 ) {
        let splitChangeBetween = parseFloat((Math.abs(difference)/0.01).toFixed(0));
        
        //if diff > 0 subtract diff from one or more subs
        //if diff < 0 add to abs of diff to subs
        //if diff = 0  || -0 (seriously small number) even split
        if(difference > 0) {
            for(let i = 0; i < splitChangeBetween; i++) {
                subs[i] = parseFloat((subs[i] - 0.01).toFixed(2));
            }
        } else if (difference < 0) {
            for(let i = 0; i < splitChangeBetween; i++) {
                subs[i] = parseFloat((subs[i] + 0.01).toFixed(2));
            }
        } 
    } else {
        //if diff > 0 subtract diff from one or more subs
        //if diff < 0 add to abs of diff to subs
        //if diff = 0  || -0 (seriously small number) even split
        if(difference > 0) {
            subs[0] = parseFloat((subs[0] - difference).toFixed(2));
        } else if (difference < 0) {
            subs[0] = parseFloat((subs[0] + Math.abs(difference)).toFixed(2));
        } 
    }

    
    //console.log(subs);
    //sum subs again
    sumSubs = 0;
    for(let i = 0; i < recipients; i++){
        sumSubs = sumSubs + subs[i];
    }
    sumSubs = parseFloat(sumSubs.toFixed(2));
    //console.log(sumSubs);
    if(sumSubs == ord) {
        //console.log("true");  
        console.log("Split Order between " + recipients + " people.");
        console.log(subs);

        console.log("Order Total ");
        console.log(ord);        
    } else {
        console.log('error');
    }    
    
}


//test the function
/*
let ord =24.95;
for(let i = 0; i < 200; i++) {
    splitOrder(16,ord);
    ord = parseFloat((ord + .01).toFixed(2));
    
}
*/

/*
//test the function
let ord =24.95;
//split between 1 - 15 ppl
for(let i = 1; i <= 15; i++) {
    //test each split 1000 times
    let split = i;
    for(let i = 0; i < 1000; i++) {
        splitOrder(split,ord);
        ord = parseFloat((ord + .01).toFixed(2));
        
    }
}
*/

splitOrder(6,24.95);