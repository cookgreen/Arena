﻿using ArenaModdingTool.ModdingFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArenaModdingTool.Forms
{
    public partial class frmKingdomRelationshipPolicyEditor : Form
    {
        private AMProject project;
        private MBKingdom kingdom;
        private List<KingdomRelationship> relationships;
        private List<KingdomPolicy> policies;
        public List<KingdomRelationship> Relationships
        {
            get { return relationships; }
        }
        public List<KingdomPolicy> Policies
        {
            get { return policies; }
        }

        public frmKingdomRelationshipPolicyEditor(AMProject project, MBKingdom kingdom)
        {
            InitializeComponent();
            this.project = project;
            this.kingdom = kingdom;
            Text = string.Format(Text, kingdom.name);
            LoadKingdomRelationships();
            LoadKingdomPolicy();
        }

        private void LoadKingdomRelationships()
        {
            foreach (var relationship in kingdom.Relationships)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = relationship.kingdom;
                lvi.SubItems.Add(relationship.value);
                lvi.SubItems.Add(relationship.isAtWar);
                relationshipList.Items.Add(lvi);
            }
        }

        private void LoadKingdomPolicy()
        {
            foreach (var policy in kingdom.Policies)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = policy.id;
                policyList.Items.Add(lvi);
            }
        }

        private void btnAddRelationship_Click(object sender, EventArgs e)
        {
            frmKingdomRelationshipAddEdit kingdomRelationshipAddEdit = new frmKingdomRelationshipAddEdit(project, kingdom, true);
            if (kingdomRelationshipAddEdit.ShowDialog() == DialogResult.OK)
            {
                var relationship = kingdomRelationshipAddEdit.Relationship;
                ListViewItem lvi = new ListViewItem();
                lvi.Text = relationship.kingdom;
                lvi.SubItems.Add(relationship.value);
                lvi.SubItems.Add(relationship.isAtWar);
                relationshipList.Items.Add(lvi);
            }
        }

        private void btnAddPolicy_Click(object sender, EventArgs e)
        {

        }

        private void btnModifyRelationship_Click(object sender, EventArgs e)
        {
            int index = relationshipList.SelectedIndices[0];
            var lvi = relationshipList.Items[index];
            KingdomRelationship relationship = new KingdomRelationship();
            relationship.kingdom = lvi.Text;
            relationship.value = lvi.SubItems[0].Text;
            relationship.isAtWar = lvi.SubItems[1].Text;
            frmKingdomRelationshipAddEdit kingdomRelationshipAddEdit = new frmKingdomRelationshipAddEdit(project, kingdom, true);
            if (kingdomRelationshipAddEdit.ShowDialog() == DialogResult.OK)
            {
                var relationshipNew = kingdomRelationshipAddEdit.Relationship;
                ListViewItem NewItem = new ListViewItem();
                NewItem.Text = relationship.kingdom;
                NewItem.SubItems.Add(relationshipNew.value);
                NewItem.SubItems.Add(relationshipNew.isAtWar);
                relationshipList.Items.Remove(lvi);
                relationshipList.Items.Insert(index, NewItem);
            }
        }

        private void btnModifyPolicy_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteRelationship_Click(object sender, EventArgs e)
        {
            int index = relationshipList.SelectedIndices[0];
            relationshipList.Items.RemoveAt(index);
        }

        private void btnDeletePolicy_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            relationships = new List<KingdomRelationship>();
            policies = new List<KingdomPolicy>();

            foreach (ListViewItem lvi in relationshipList.Items)
            {
                KingdomRelationship relationship = new KingdomRelationship();
                relationship.kingdom = lvi.Text;
                relationship.value = lvi.SubItems[0].Text;
                relationship.isAtWar = lvi.SubItems[1].Text;
                relationships.Add(relationship);
            }

            foreach (ListViewItem lvi in policyList.Items)
            {
                KingdomPolicy policy = new KingdomPolicy();
                policy.id = lvi.Text;
                policies.Add(policy);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void relationshipList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (relationshipList.SelectedIndices.Count > 0)
            {
                btnModifyRelationship.Enabled = true;
                btnDeleteRelationship.Enabled = true;
            }
            else
            {
                btnModifyRelationship.Enabled = false;
                btnDeleteRelationship.Enabled = false;
            }
        }

        private void policyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (policyList.SelectedIndices.Count > 0)
            {
                btnModifyPolicy.Enabled = true;
                btnDeletePolicy.Enabled = true;
            }
            else
            {
                btnModifyPolicy.Enabled = false;
                btnDeletePolicy.Enabled = false;
            }
        }
    }
}
