# Restore Original Design

To restore the original design, follow these steps:

## Option 1: Manual Restore
1. Delete `Components\Pages\CharacterList.razor`
2. Rename `Components\Pages\CharacterList.razor.backup` to `CharacterList.razor`
3. Delete `wwwroot\app.css`
4. Rename `wwwroot\app.css.backup` to `app.css`

## Option 2: Command Line (Run in project root)
```cmd
copy /Y Components\Pages\CharacterList.razor.backup Components\Pages\CharacterList.razor
copy /Y wwwroot\app.css.backup wwwroot\app.css
```

## Files Backed Up:
- `Components\Pages\CharacterList.razor.backup` - Original character list page
- `wwwroot\app.css.backup` - Original CSS styles

After restoring, rebuild and run the project.
