import{_ as E,o as I,a as y,k as D,b as F,A as c,c as r,K as B,M as O,d as P,V as j,O as N,E as G,e as d,f as t,g as K,t as u,F as _,r as V,h as n,w as C,l as L,P as T,i as a,j as l,m as U,p as q,n as z}from"./index.8cc3069d.js";const H={setup(){async function s(){try{await y.getMyVaults()}catch(o){L.error(o),T.error(o)}}return I(()=>{y.getAccount(),s(),D.getAllKeeps()}),F(()=>{c.vaults=[],c.keeps=[]}),{account:r(()=>c.account),vaults:r(()=>c.myVaults),keeps:r(()=>{var o;return(o=c.keeps)==null?void 0:o.filter(m=>{var e;return m.creatorId==((e=c.account)==null?void 0:e.id)})})}},components:{KeepCard:B,Modal:O,KeepDetails:P,VaultCard:j,OffCanvas:N,EditAccountForm:G}},p=s=>(q("data-v-75fedcc7"),s=s(),z(),s),J={class:"container"},Q={class:"row justify-content-center mt-4"},R={class:"col-lg-12 d-flex justify-content-center"},W=["src"],X={class:"col-lg-12 d-flex flex-column align-items-center user-details"},Y=["src"],Z={class:"mt-3"},$=p(()=>t("button",{title:"Edit account details.",class:"btn btn-outline-dark",type:"button","data-bs-toggle":"offcanvas","data-bs-target":"#edit-account","aria-controls":"edit-account"},[t("i",{class:"mdi mdi-pen"})],-1)),tt=K(" | "),et=p(()=>t("h3",null,"Vaults",-1)),st={class:"row"},ot={class:"col-6 col-sm-4 mb-3"},ct={class:"col-12"},at=p(()=>t("h3",null,"Keeps",-1)),nt={class:"masonry"};function lt(s,o,m,e,dt,it){var v,f,h,g,k;const x=a("VaultCard"),A=a("KeepCard"),b=a("KeepDetails"),S=a("Modal"),M=a("EditAccountForm"),w=a("OffCanvas");return l(),d(_,null,[t("div",J,[t("div",Q,[t("div",R,[t("div",null,[t("img",{class:"cover-image",src:(v=e.account)==null?void 0:v.coverImg,alt:""},null,8,W)])]),t("div",X,[t("img",{class:"profile-picture rounded-circle",src:(f=e.account)==null?void 0:f.picture,alt:""},null,8,Y),t("div",Z,[t("h1",null,[K(u((h=e.account)==null?void 0:h.name)+" ",1),$])]),t("div",null,[t("span",null,u((g=e.vaults)==null?void 0:g.length)+" vaults",1),tt,t("span",null,u((k=e.keeps)==null?void 0:k.length)+" keeps",1)])]),et,t("div",st,[(l(!0),d(_,null,V(e.vaults,i=>(l(),d("div",ot,[n(x,{vault:i,title:"Go to Vault"},null,8,["vault"])]))),256))]),t("div",ct,[at,t("section",nt,[(l(!0),d(_,null,V(e.keeps,i=>(l(),U(A,{keep:i,title:"See Keep Details"},null,8,["keep"]))),256))])])])]),n(S,{id:"keep-details"},{default:C(()=>[n(b)]),_:1}),n(w,{id:"edit-account"},{default:C(()=>[n(M)]),_:1})],64)}const ut=E(H,[["render",lt],["__scopeId","data-v-75fedcc7"]]);export{ut as default};
